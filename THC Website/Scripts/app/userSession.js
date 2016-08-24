var userSession = (function (apApi) {

    var sessionStateName = 'userSession';

    var userSessionState = {

        userId: '', //employee_id
        username: '',

        firstname: '',
        lastname: '',
        email: '',
        phone: '', //work_phone

        userType: {},
        location: {},
        isLoggedIn: false
    };

    function getUserSession() {
        return userSessionState;
    }

    function saveUserSession() {
        console.log("save user session");

        //sessionStorage.setItem(sessionStateName, '{test: "test", num: 1}');
        sessionStorage.setItem(sessionStateName, JSON.stringify(userSessionState));
    }

    function loadUserSession() {
        //console.log("load user session");
        var savedSession = sessionStorage.getItem(sessionStateName);

        if (savedSession) {
            savedSession = JSON.parse(savedSession);
            userSessionState = savedSession;
        }
    }

    function login(username, pwd) {
        var redirectUrl = window.location.origin + "/Appointments/Appointments";

        var options = { 
            first_name: username,
            last_name: pwd
        };

        apApi.getStaff(options).success(function (data) {
            if (data.count == 1) {
                var staff = data.data[0];
                console.log(staff);

                userSessionState.userId = staff.employee_id;
                userSessionState.username = username;

                var name = staff.screen_name.split('|');
                if (name.length == 2) {
                    userSessionState.firstname = name[0];
                    userSessionState.lastname = name[1];
                }
                userSessionState.email = staff.email;
                userSessionState.phone = staff.work_phone;

                userSessionState.isLoggedIn = true;
                
                apApi.getLocations({ c_id: staff.c_id }).success(function (data) {
                    userSessionState.location = data.data[0];

                    apApi.getStaffTypes().success(function (data) {
                        var staffTypes = data.data;
                        
                        var staffType = staffTypes.filter(function (element, index, array) {
                            return element.type_id === staff.type_id;
                        });

                        if (staffType && staffType.length === 1) {
                            userSessionState.userType = staffType[0];
                        }

                        saveUserSession();
                        //$('#linkLogin').trigger('loginStateChange');
                        window.location = redirectUrl;
                        return true;
                    });
                  
                });
              
            } else {
                window.alert("Login failed");
                return false;
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            window.alert("Network error");
            return false;
        });
      
    }

    function logout() {
        var redirectUrl = window.location.origin;

        userSessionState.isLoggedIn = false;
        //saveUserSession();
        sessionStorage.clear();

        window.location = redirectUrl;
    }

    function isUserLoggedIn() {
        return userSessionState.isLoggedIn;
    }

    function enforceLogin() {
        if (!userSession.isUserLoggedIn()) {
            window.location = window.location.origin + "/Account";
        }
    }

    var api = {
        getUserSession: getUserSession,
        saveUserSession: saveUserSession,
        loadUserSession: loadUserSession,
        login: login,
        logout: logout,
        isUserLoggedIn: isUserLoggedIn,
        enforceLogin: enforceLogin
    };

    return api;
})(ap_webApi);
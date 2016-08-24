var accountManager = (function (apApi) {
    var service = {
        createStaff: createStaff,
        updateStaff: updateStaff,
        activateStaff: activateStaff,
        deleteStaff: deleteStaff,

        createPatient: createPatient,
        updatePatient: updatePatient,
        deletePatient: deletePatient
    };

    function createStaff(firstname, lastname, email, phone, username, pwd, locationId, typeId) {
        var options = {
            c_id: locationId,
            screen_name: firstname + '|' + lastname,
            first_name: username,
            last_name: pwd,
            email: email,
            work_phone: phone,
            type_id: typeId,
            status: "Active"
        };

        return apApi.createStaff(options);
    }

    function updateStaff(options) {
        return apApi.updateStaff(options);
    }

    function activateStaff(userId) {
        var options = {
            employee_id: userId,
            status: 'Active'
        };

        return apApi.updateStaff(options);
    }

    function deleteStaff() {

    }

    function createLocation() {

    }

    function updateLocation() {

    }

    function deleteLocation() {

    }

    function createPatient() {

    }

    function updatePatient() {

    }

    function deletePatient() {

    }

    return service;
})(ap_webApi);
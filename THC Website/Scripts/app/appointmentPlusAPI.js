var ap_webApi = (function (window, _, undefined) {

    var baseUrl = "https://ws.appointment-plus.com"; //ws1 or ws2 would work too
    var siteId = "appointplus395/42";
    var apiKey = "0183c59972626a190a39190fd900499ad3664d71";

    return {
        //Appointments
        getAppointments: getAppointments,
        createAppointment: createAppointment,
        updateAppointment: updateAppointment,
        cancelAppointment: cancelAppointment,

        //Locations
        getLocations: getLocations,

        //Staff
        getStaff: getStaff,
        getStaffTypes: getStaffTypes,
        createStaff: createStaff,
        updateStaff: updateStaff,

        //Patient
        getPatients: getPatients,
        createPatient: createPatient,
        updatePatient: updatePatient,
        deletePatient: deletePatient,

        testCalling: testCalling
    };

    function testCalling(input) {
        if (input === true) {
            window.alert('test Calling successful');
        } else {
            window.alert('test Calling failed');
        }
            
        return input;
    }

    //Appointments
    function getAppointments(options) {
        var uri = "/Appointments/GetAppointments";
        return invokeApi(uri, options, "GET");
    }

    function createAppointment(options) {
        var uri = "/Appointments/CreateAppointments";
        return invokeApi(uri, options, "POST");
    }

    function updateAppointment(options) {
        var uri = "/Appointments/UpdateAppointments";
        return invokeApi(uri, options, "POST");
    }

    function cancelAppointment(appointmentId) {
        var uri = "/Appointments/CancelAppointments";
        var options = {
            appt_id : appointmentId
        }
        return invokeApi(uri, options, "POST");
    }

    //Locations
    function getLocations(options) {
        var uri = "Locations/GetLocations";
        return invokeApi(uri, options, "GET");
    }

    //Staff
    function getStaff(options) {
        var uri = "/Staff/GetStaff";
        return invokeApi(uri, options, "GET");
    }

    function getStaffTypes() {
        var uri = "/Staff/GetStaffTypes";
        return invokeApi(uri, {}, "GET");
    }

    function createStaff(options) {
        var uri = "/Staff/CreateStaff";
        return invokeApi(uri, options, "POST");
    }

    function updateStaff(options) {
        var uri = "/Staff/UpdateStaff";
        return invokeApi(uri, options, "POST");
    }

    //Patients
    function getPatients(options) {
        var uri = "/Customers/GetCustomers";
        return invokeApi(uri, options, "GET");
    }

    function createPatient(options) {
        var uri = "/Customers/CreateCustomers";
        return invokeApi(uri, options, "POST");
    }

    function updatePatient(options) {
        var uri = "/Customers/UpdateCustomers";
        return invokeApi(uri, options, "POST");
    }

    function deletePatient(options) {
        var uri = "/Customers/DeleteCustomers";
        return invokeApi(uri, options, "POST");
    }

    //Basic API Invoking function
    function invokeApi(uri, options, httpVerb) {

        if (!httpVerb) httpVerb = 'GET';
        if (uri.indexOf('/') !== 0) uri = '/' + uri;
        var apiUrl = baseUrl + uri;

        var dataBasic = {
            response_type: 'jsonp',
            site_id: siteId,
            api_key: apiKey
        };

        var dataComponent = _.assign(dataBasic, options);

        return $.ajax({
            data: dataComponent,
            dataType: "jsonp",
            //jsonpCallback: myFunc1,
            type: httpVerb,
            url: apiUrl,
        });
        //    .done(function (data) {
        //    //console.log(data);
        //    return data;
        //}).fail(function (jqXHR, textStatus, errorThrown) {
        //    //console.log(textStatus);
        //    return "Request failed: " + textStatus;
        //});

        //var result = $.ajax({
        //    data: dataComponent,
        //    dataType: "jsonp",
        //    //jsonpCallback: myFunc1,
        //    type: httpVerb,
        //    url: apiUrl,
        //    error: function (jqXHR, textStatus, errorThrown) {
        //        console.log('error');
        //        console.log(textStatus);
        //        console.log(errorThrown);
        //        return "error: " + textStatus;
        //    },
        //    success: function (data) {
        //        //console.log(data);
        //        return data;
        //    }
        //});
    }

})(window, _);


/* [Staff member types]

 * System Admin
 * Facility Admin
 * Doctor Office Admin
 * Facility Staff
 * Doctor Office Staff
 * Patient
 * 
 */
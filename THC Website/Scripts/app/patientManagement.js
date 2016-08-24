var patientManager = (function (apApi, userSession) {

    var service = {
        loadData: loadData,
        insertItem: insertItem,
        updateItem: updateItem,
        deleteItem: deleteItem,
        getPatientById: getPatientById
    };

    return service;

    function getPatientById(patientId) {
        var options = {
            customer: patientId
        };

        var d = $.Deferred();

        apApi.getPatients(options).done(function (response) {
            console.log(response);
            if (response.data) {
                var patient = mapPatientServerToClient(response.data[0]);
                d.resolve(patient);
            } else {
                d.reject('Patient not found');
            }
        });

        return d.promise();
    }

    function loadData(filter) {
        var locationId = getLocationId();
        if (!locationId || locationId < 0) {
            alert('Cannot load data. Location is not set');
            return [];
        }
        
        //console.log(filter);
        var options = {
            location: locationId
        };

        if (filter) {
            if (filter.patientId) {
                options.customer = filter.patientId;
            }

            if (filter.firstName) {
                options.first_name_search = filter.firstName;
            }

            if (filter.lastName) {
                options.last_name_search = filter.lastName;
            }
        }

        var d = $.Deferred();

        apApi.getPatients(options).done(function (response) {
            console.log(response);
            var data = response.data;
            var patients = [];

            if (data) {
                data.forEach(function (element) {
                    var patient = mapPatientServerToClient(element);
                    if (patient) {
                        patients.push(patient);
                    }
                });
            }

            d.resolve(patients);
        });

        return d.promise();
    }

    function insertItem(item) {
        console.log('insert item, displaying item');
        console.log(item);

        var locationId = getLocationId();
        var options = mapPatientClientToServer(item);
        options.c_id = locationId;

        //alert(printObj(options));
        console.log('displaying mapped data');
        console.log(options);

        

        var errMsg = 'Error adding new patient';

        var d = $.Deferred();
        apApi.createPatient(options).done(function (response) {
            console.log(response);
            if (response.result == 'fail') {
                var failMsg = response.errors[0];
                window.alert(errMsg + ' ' + failMsg);
                d.reject(errMsg + ' ' + failMsg);
            } else {
                if (response.data) {
                    var patientId = response.data.customer_id;

                    getPatient(patientId, getLocationId()).done(function (res) {
                        var data = res.data[0];
                        var patient = mapPatientServerToClient(data);
                        d.resolve(patient);
                    });
                } else {
                    window.alert(response.data);
                    window.alert(errMsg);
                    d.reject(errMsg);
                }
            }
        }).fail(function() {
            d.reject(errMsg);
        });

        return d.promise();
    }

    function updateItem(item) {

        var options = mapPatientClientToServer(item);
        
        var d = $.Deferred();

        console.log(options);

        apApi.updatePatient(options).done(function (response) {
            var patientId = response.data.customer_id;

            getPatient(patientId, getLocationId()).done(function(res) {
                var data = res.data[0];
                var patient = mapPatientServerToClient(data);
                d.resolve(patient);
            });
        });

        return d.promise();
    }

    function deleteItem(item) {
        var options = {
            customer_id: item.patientId
        };
        return apApi.deletePatient(options);
    }

    function getPatient(patientId, location) {
        var options = {
            customer: patientId,
            location: location
        };

        return apApi.getPatients(options);
    }

    function getLocationId() {
        var currUser = userSession.getUserSession();
        return currUser.location.location_id;
    }

    function mapPatientServerToClient(serverPatient) {
        if (!serverPatient) {
            return;
        }

        var clientPatient = {
            patientId: serverPatient.customer_id,
            lastName: serverPatient.last_name,
            firstName: serverPatient.first_name,
            DOB: moment(serverPatient.birth_date, 'YYYYMMDD').format('YYYY-MM-DD'),
            email: serverPatient.email,
            phone: serverPatient.day_phone,
            fin: serverPatient.employer, //mapping to employer due to api limition
            tcEligible: serverPatient.contact_okay == 'yes' ? true : false,
            //tcEligible: serverPatient.contact_okay ? true : false,
            insurance: serverPatient.call_okay == 'yes' ? true : false,
            typeIns: serverPatient.occupation
        };
        return clientPatient;
    }

    function mapPatientClientToServer(clientPatient) {
        var birthdayString = ''; //yyyymmdd 
        printObj(clientPatient);
        if (clientPatient.DOB) {
            //birthdayString = clientPatient.DOB.getFullYear() + clientPatient.DOB.getMonth() + clientPatient.DOB.getDate();
            birthdayString = moment(clientPatient.DOB).format('YYYYMMDD');
        }
        var serverPatient = {
            customer_id: clientPatient.patientId,
            last_name: clientPatient.lastName,
            first_name: clientPatient.firstName,
            birth_date: birthdayString,
            email: clientPatient.email,
            day_phone: clientPatient.phone,
            employer: clientPatient.fin, //mapping to employer due to api limition
            contact_okay: clientPatient.tcEligible ? 'yes': 'no',
            call_okay: clientPatient.insurance ? 'yes' : 'no',
            occupation: clientPatient.typeIns
        };

        return serverPatient;
    }

    function printObj(object) {
        var output = '';
        for (var property in object) {
            output += property + ': ' + object[property] + '; ';
        }
        return output;
    }

})(ap_webApi, userSession);
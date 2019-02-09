     //Added Ajax call to calendar.js, also made changes to controllers and views in appropriate places (not shown)
     
       eventClick: function (event, jsEvent, view) {
            jQuery.ajax({
                'url': EditWorkTimeEventURL,
                'type': 'GET',
                'data': {
                    id: event.id
                },
                'success': function (data) {
                    document.getElementById("userEditModalBody").innerHTML = data;
                    //figure out how to display data in modal
                },
                error: function () {
                    alert("An error Occurred.  Please try again or contact your system administrator.");
                }
            })
﻿function railGun() {
    $.ajax({
        cache: false,
        url: 'GDO/ToggleDoor',
        type: 'GET',
        data: "",
        success: function (data) {
            //if (data != null) {
            //    if (data.Message == "Already executed") alert("Cannot play this animation again. Please choose another animation.");
            //} else {
            //    alert("An error has occurred.");
            //}
        },
        error: function (e) {
            alert("An error has occurred.");
        }
    });
}
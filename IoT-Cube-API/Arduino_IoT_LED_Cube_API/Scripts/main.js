function railGun() {
    $.ajax({
        url: 'CubeControl/SendCommand/0',
        type: 'GET',
        data: "",
        success: function (data) {
           
        },
        error: function (e) {
            alert(e);
        }
    });
}

function cornerCube() {
    $.ajax({
        url: 'CubeControl/SendCommand/1',
        type: 'GET',
        data: "",
        success: function (data) {

        },
        error: function (e) {
            alert(e);
        }
    });
}
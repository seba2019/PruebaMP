$(document).ready(() => {
    $.ajax({
        url: "Home/CreateOrder",
        method: "get",
        success: (e) => {
            console.log(e);
        },
        error: (e) => {
            console.log(e);
        }
    })
});

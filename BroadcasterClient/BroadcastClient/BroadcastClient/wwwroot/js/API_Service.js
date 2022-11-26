async function apiCall(url, model,token) {
    if (confirm("Are You Sure Want to do this Action")) {
        return await $.ajax({
            url: url,
            type: "Post",
            dataType: 'json',
            headers: {
                'Authorization': 'Bearer ' + token
            },
            data: model,
        });
    }
    return null;
};
async function tokenGatter() {

    return await $.ajax({
        url: "https://localhost:44371/Home/GetToken",
        type: "Get",
        dataType: 'json',
    });
}
 async function apiCall(url, token) {

    return await $.ajax({
        url: url,
        type: "Get",
        headers: {
            'Authorization': 'Bearer ' + token
        },
        dataType: 'json',
    });
}

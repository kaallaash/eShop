function login() {
    let loginForm = document.getElementById('loginForm');

    function sendLoginRequest(username, password) {
        let data = {
            username: username,
            password: password
        };

        let xhr = new XMLHttpRequest();
        let promise = new Promise((resolve, reject) => {
            xhr.open('POST', 'https://localhost:7267/api/token');
            xhr.setRequestHeader('Content-Type', 'application/json');

            xhr.onload = function () {
                if (xhr.status === 200) {
                    let response = JSON.parse(xhr.responseText);
                    const tokenType = 'Bearer';
                    sessionStorage.setItem('Authorization', `${tokenType} ${response.accessToken}`);
                    sessionStorage.setItem('RefreshToken', response.refreshToken);
                    sessionStorage.setItem('ExpiryTime', response.expiryTime);

                    resolve(response.accessToken);
                } else {
                    reject(Error('Ошибка ' + xhr.status + ': ' + xhr.statusText));
                }
            };

            xhr.onerror = function () {
                reject(Error('Сетевая ошибка'));
            };

            xhr.send(JSON.stringify(data));
        });

        return promise;
    }

    loginForm.addEventListener('submit', function (event) {
        event.preventDefault();

        let username = loginForm.elements.Username.value;
        let password = loginForm.elements.Password.value;

        sendLoginRequest(username, password)
            .then(function () {
                loginForm.submit();
            })
            .catch(function (error) {
                loginForm.submit();
                console.error(error);
            });
    });
}
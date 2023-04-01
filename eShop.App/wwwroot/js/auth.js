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
                    sessionStorage.setItem('AccessToken', `${tokenType} ${response.accessToken}`);
                    sessionStorage.setItem('RefreshToken', response.refreshToken);
                    sessionStorage.setItem('ExpiryTime', response.expiryTime);
                    document.cookie = `RefreshToken = ${response.refreshToken}; expires=Thu, 01 Jan 2099 00:00:00 UTC; path=/;`;
                    document.cookie = `ExpiryTime = ${response.expiryTime}; expires=Thu, 01 Jan 2099 00:00:00 UTC; path=/;`;
                    document.cookie = `AccessToken = ${response.accessToken}; expires=Thu, 01 Jan 2099 00:00:00 UTC; path=/;`;

                    resolve(response.accessToken);
                }
                else {
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

function logout() {
    sessionStorage.removeItem('AccessToken');
    sessionStorage.removeItem('RefreshToken');
    sessionStorage.removeItem('ExpiryTime');
    document.cookie = "RefreshToken=; max-age=0; path=/;";
    document.cookie = "ExpiryTime=; max-age=0; path=/;";
    document.cookie = "AccessToken=; max-age=0; path=/;";
}
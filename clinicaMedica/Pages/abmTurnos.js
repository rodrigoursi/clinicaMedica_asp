let myModal = new bootstrap.Modal(document.getElementById("obsMedModal"));
let urlParams = new URLSearchParams(window.location.search);
let id = urlParams.get('id');
if (id) myModal.show();


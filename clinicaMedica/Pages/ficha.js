const select = document.getElementById("ContentPlaceHolder1_AltaUsuario_loc");
const modal = document.getElementById("modal_cargarLoc_user");
select.addEventListener("change", () => {
    if (select.value == "nuevo") {
        modal.classList.toggle("cerrarModal");
    }
});

const x = document.getElementById("modal_cargarLoc_X");
const cerrar = document.getElementById("modal_cargarLoc_X");

eventosModal(x, modal);
eventosModal(cerrar, modal);

function eventosModal(boton, modal) {
    boton.addEventListener("click", () => {
        modal.classList.toggle("cerrarModal");
    });
}
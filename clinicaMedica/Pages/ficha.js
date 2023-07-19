const select = document.getElementById("ContentPlaceHolder1_AltaUsuario_loc");
const modal = document.getElementById("modal_cargarLoc_user");
select.addEventListener("change", () => {
    if (select.value == "nuevo") {
        modal.classList.toggle("cerrarModal");
    }
});

const x = document.getElementById("modal_cargarLoc_X");
const cerrar = document.getElementById("modal_cargarLoc_cerrar");

eventosModal(x, modal);
eventosModal(cerrar, modal);

const inputs = document.querySelectorAll(".formulario input");
const submit = document.getElementById("ContentPlaceHolder1_AltaUsuario_agregar");
let apagar = true;
inputs.forEach(input => {
    
    input.addEventListener("blur", () => {
        apagar = false;
        inputs.forEach((elem, i) => {
            if (i != 0 && i < 10) {
                if (elem.value == "") {
                    apagar = true;
                }
                console.log(i);
            }
        });
        console.log(apagar)
        if (apagar) {
            submit.disabled = true;
        } else submit.removeAttribute("disabled");
    })
})
console.log(apagar)
if (apagar) {
    submit.disabled = true;
} else submit.removeAttribute("disabled");



function eventosModal(boton, modal) {
    boton.addEventListener("click", () => {
        modal.classList.toggle("cerrarModal");
        console.log(modal);
    });
}
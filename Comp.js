function validacion(){
    let nombre;
    let apellido;
    let correo;
    let telefono;
    let password;  
        
    nombre = document.getElementById('nombre').value;
    error = document.getElementById('error');
    apellido = document.getElementById('apellido').value;
    correo = document.getElementById('correo').value;
    telefono = document.getElementById('telefono').value;
    password = document.getElementById('password').value;  

    let expresionCorreo = /(^[0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$/;
    
    if(nombre === "" || apellido === "" || correo === "" || telefono === "" || password === "" || pais === "" || fecha === ""){
        
        alert('no puedes dejar nigun campo vacio');    
        return false;    
    }
    else if(nombre.length > 20 || apellido.length > 20){
        alert('nombre y apellido solo 20 caracteres maximo');
        return false;
    }
    else if(correo.length > 40){
        alert('el correo es muy largo, debe ser menos de 40 caracteres');
        return false;
    }
    else if(!expresionCorreo.test(correo)){
        alert('el correo no es valido');
        return false;
    }
    else if(isNaN(telefono)){
        alert('el telefono no es valido');
        return false;
    }
    else if(telefono.length < 10){
        alert('el telefono es muy corto, 10 digitos como minimo');
        return false;
    } 
    
    alert('FORMULARIO ENVIADO CON EXITO');
}
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const toggleBtn = document.getElementById("navToggle");
const menu = document.getElementById("navMenu");
const indexText = document.getElementById("indexDisplayText");
let loginBlock = document.getElementById("loginGlassCard");


let count = 0;



toggleBtn.addEventListener("click", () => {
    menu.classList.toggle("active");
    menu.hidden = false;
    indexText.style.marginTop = '149px';

    //if (loginBlock != null) {
    //   // loginBlock.style.marginTop = '20%';
    //    console.log('Found the element');
    //}
    //else
    //{
    //    console.log('Element too far ' + loginBlock);
    //}

    count += 1;
    if (count>1)
    {
       
        indexText.style.marginTop = "10px";
       // loginBlock.style.marginTop = "5%";
        
        count = 0;
    }
    
});


   


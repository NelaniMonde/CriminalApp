
// for details on configuring this project to bundle and minify static web assets.

// elements and button variables 
const toggleBtn = document.getElementById("navToggle");
const menu = document.getElementById("navMenu");
const indexText = document.getElementById("indexDisplayText");
const suspectView = document.getElementById("addSuspectView");
const managerView = document.getElementById("addManagerView");
const dashboardView = document.getElementById("dashBoardView");
const showsuspectView = document.getElementById("showsuspectsView");
const updateCriminalRecView = document.getElementById("updateCriminalRec");
const viewCasesView = document.getElementById("viewCases");
const updateSuspectView = document.getElementById("updateSuspect");


let count = 0;


//nav button even listener
toggleBtn.addEventListener("click", () => {
    menu.classList.toggle("active");
    menu.hidden = false;
   
    //element event conditions
    if (indexText != null) {
        indexText.style.marginTop = '149px';
    }
    if (suspectView != null)
    {
        suspectView.style.marginTop = '259px';
    }
    if (managerView != null)
    {
        managerView.style.marginTop = '259px';
    }

    if (dashboardView != null)
    {
        dashboardView.style.marginTop = '259px';
    }

    if (showsuspectView != null)
    {
        showsuspectView.style.marginTop = '259px';
    }

    if (updateCriminalRecView != null)
    {
        updateCriminalRecView.style.marginTop = '259px';
    }

    if (viewCasesView != null)
    {
        viewCasesView.style.marginTop = '259px';
    }

    if (updateSuspectView != null)
    {
        updateCriminalRecView.style.marginTop = '259px';
    }

    //doing a count for when the nav button is clicked once more
    count += 1;

    if (count>1)
    {
        //going back to normal condition 
        if (indexText != null)
        {
            indexText.style.marginTop = "10px";
        }

        if (suspectView != null)
        {
            suspectView.style.marginTop = '20px';
        }

        if (managerView != null) {
            managerView.style.marginTop = '20px';
        }

        if (dashboardView != null) {
            dashboardView.style.marginTop = '8%';
        }

        if (showsuspectView != null) {
            showsuspectView.style.marginTop = '8%';
        }

        if (updateCriminalRecView != null) {
            updateCriminalRecView.style.marginTop = '12%';
        }

        if (viewCasesView != null) {
            viewCasesView.style.marginTop = '8%';
        }

        if (updateSuspectView != null) {
            updateCriminalRecView.style.marginTop = '8%';
        }
        
        count = 0;
    }
    
});


   


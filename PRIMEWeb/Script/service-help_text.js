// Service name label display
var serviceNameBtn = document.querySelector("#ServiceNameImg");
var ServiceNamelabel = document.querySelector("#lblServiceName");

serviceNameBtn.addEventListener('mouseover', () => {
    ServiceNamelabel.style.visibility = "visible";
});

serviceNameBtn.addEventListener('mouseout', () => {
    ServiceNamelabel.style.visibility = "hidden";
});

// warranty label display
var serviceDescnBtn = document.querySelector("#ServiceDescImg");
var ServiceDesclabel = document.querySelector("#lblServiceDesc");

serviceDescnBtn.addEventListener('mouseover', () => {
    ServiceDesclabel.style.visibility = "visible";
});

serviceDescnBtn.addEventListener('mouseout', () => {
    ServiceDesclabel.style.visibility = "hidden";
});

// warranty label display
var servicePriceBtn = document.querySelector("#PriceImg");
var ServicePricelabel = document.querySelector("#lblPrice");

servicePriceBtn.addEventListener('mouseover', () => {
    ServicePricelabel.style.visibility = "visible";
});

servicePriceBtn.addEventListener('mouseout', () => {
    ServicePricelabel.style.visibility = "hidden";
});
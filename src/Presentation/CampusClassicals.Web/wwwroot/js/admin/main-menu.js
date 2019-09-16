$(document).ready(function () {
    var page = window.location.pathname.toString().split("/").pop();

    switch (page.toLowerCase()) {
        case "admin":
        case "dashboard": {
            UpdateLink("active", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            break;
        }
        case "gallery": {
            UpdateLink("", "active", "active", "", "", "", "", "", "", "", "", "", "", "", "");
            break;
        }
        case "events": {
            UpdateLink("", "active", "", "active", "", "", "", "", "", "", "", "", "", "", "");
            break;
        }
    }

    //lnkDashboard lnkMedia lnkGallery lnkEvents lnkMainSlider lnkWelcome lnkSchools lnkAccessControl lnkRole lnkUsers lnkRoleAssignment lnkSettings lnkGeneral lnkSocialMedia lnkGrandFinale                     
});

function UpdateLink(dashboard, media, gallery, events, mainSlider, welcome, schools, accessControl, role, users, roleAssignment, settings, general, socialMedia, grandFinale) {

    $("#lnkDashboard").addClass(dashboard);

    $("#lnkMedia").addClass(media);
    $("#lnkGallery").addClass(gallery);
    $("#lnkEvents").addClass(events);
    $("#lnkMainSlider").addClass(mainSlider);
    $("#lnkWelcome").addClass(welcome);
    $("#lnkSchools").addClass(schools);

    $("#lnkAccessControl").addClass(accessControl);
    $("#lnkRole").addClass(role);
    $("#lnkUsers").addClass(users);
    $("#lnkRoleAssignment").addClass(roleAssignment);

    $("#lnkSettings").addClass(settings);
    $("#lnkGeneral").addClass(general);
    $("#lnkSocialMedia").addClass(socialMedia);
    $("#lnkGrandFinale").addClass(grandFinale);
}

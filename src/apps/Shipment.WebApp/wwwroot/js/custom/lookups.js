$("#BillToCountryDropDown").change(function () {
    let selectedCountryId = $(this).val();
    $.ajax({
        url: $("#hdnStatesUrl").val(),
        type: "GET",
        data: {countryId: selectedCountryId},
        success: function (response) {
            refreshStates(response);
            console.log("State selection successful:", response);

        },
        error: function (error) {
            console.error("Error during state selection:", error);
        }
    });
});

function refreshStates(response) {
    let stateDropdown = $("#ddlBillToState");
    stateDropdown.empty();
    stateDropdown.append($("<option>").text('Select State').val(''));
    $.each(response, function (index, item) {
        stateDropdown.append($("<option>").text(item.stateName).val(item.id));
    });
}
$("#ShipToCountryDropDown").change(function () {
    let selectedCountryId = $(this).val();
    $.ajax({
        url: $("#hdnStatesUrl").val(),
        type: "GET",
        data: {countryId: selectedCountryId},
        success: function (response) {
            ShipRefreshStates(response);
            console.log("State selection successful:", response);

        },
        error: function (error) {
            console.error("Error during state selection:", error);
        }
    });
});

function ShipRefreshStates(response) {
    let stateDropdown = $("#ddlShipToState");
    stateDropdown.empty();
    stateDropdown.append($("<option>").text('Select State').val(''));
    $.each(response, function (index, item) {
        stateDropdown.append($("<option>").text(item.stateName).val(item.id));
    });
}
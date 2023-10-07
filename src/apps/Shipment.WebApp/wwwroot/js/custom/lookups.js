// Bill Country DropDown
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

// Ship Country DropDown
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

function disableShipToFields() {
    $(".ship-to-column").find("input[type='text'],input[type='email'],select").each(function (d) {
        $(this).val("");
        $(this).attr("disabled", "disabled");
    });
}

function enableShipToFields(){
    $(".ship-to-column").find("input[type='text'],input[type='email'],select").each(function (d) {
        $(this).removeAttr("disabled");
    }); 
}

function showFile(){
    $('#file-upload-column').css("visibility", "visible");
    $('#taxExemptFile').attr("required", "required");
}

function hideFile(){
    $('#file-upload-column').css('visibility', 'hidden');
    $('#taxExemptFile').removeAttr("required");
}

$("#SameAsBillTo").on("change", function () {
    let isChecked = $(this).is(":checked");
    if (isChecked) {
        disableShipToFields();
    } else {
        enableShipToFields();
    }
});

$('#radioButtonTaxExemptYes').change(function () {
    if ($(this).is(':checked')) {
        showFile();
    } else {
        hideFile();
    }
});

$('#radioButtonTaxExemptNo').change(function () {
    if ($(this).is(':checked')) {
        hideFile();
    }
});

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

$("#SameAsBillTo").on("change", function () {
    let isChecked = $(this).is(":checked");
    if (isChecked) {
        $(".ship-to-column").find("input[type='text'],input[type='email'],select").each(function (d) {
            $(this).val("");
            $(this).attr("disabled", "disabled");
        });
    } else {
        $(".ship-to-column").find("input[type='text'],input[type='email'],select").each(function (d) {
            $(this).removeAttr("disabled");
        });
    }
});
$('#radioButtonTaxExemptYes').change(function () {
    if ($(this).is(':checked')) {
        $('#file-upload-column').css("visibility", "visible");
    } else {
        $('#file-upload-column').css('visibility', 'hidden');
    }
});

$('#radioButtonTaxExemptNo').change(function () {
    if ($(this).is(':checked')) {
        $('#file-upload-column').css('visibility', 'hidden');
    }
});

/*
$('#radioButtonTaxExemptYes').change(function () {
    if ($(this).is(':checked')) {
        $('.file-upload-column').removeAttr('hidden');  // Remove the hidden attribute to show the file input field
    } else {
        $('.file-upload-column').attr('hidden', true);  // Add the hidden attribute to hide the file input field
    }
});
$('#radioButtonTaxExemptNo').change(function () {
    if ($(this).is(':checked')) {
        $('.file-upload-column').attr('hidden', true);
    }
});*/


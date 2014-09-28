
/*************************************************************************************************************/

function liveSearchFor(url, elementSelector, callbackMethod) {

    var searching = false;

    $(elementSelector).keyup(function() {

        $('#divLiveSearchResult').remove();

        var searchStr = $(elementSelector).val();

        if (searchStr === null || searchStr === '') {
            return;
        }

        // $('#divLiveSearchResult').remove();

        if (searching) {
            return;
        }

        searching = true;

        $.ajax({
            url: url + '?query=' + searchStr,
            type: 'GET',
            success: function(data) {
                
                var $searchResult = $('<div id="divLiveSearchResult" class="list-group"></div>');

                $searchResult.css('position', 'absolute', 'important');
                $searchResult.css('z-index', '1000', 'important');
                $searchResult.css('width', $(elementSelector).width() + 60, 'important');
                $searchResult.css('top', $(elementSelector).position().top + 35, 'important');

                var text = '';

                $.each(data, function(index, value) {
                    text += '<a href="#" class="list-group-item" data-id="' + value.Id + '" data-name="' + value.Fullname + '">' +
                        '<h5 class="list-group-item-heading">' + value.Fullname + '</h5>';

                    if (value.MobileNumber != null) {
                        text += '<p class="list-group-item-text">' + value.MobileNumber + '</p>';
                    }

                    if (value.PhoneNumber != null) {
                        text += '<p class="list-group-item-text">' + value.PhoneNumber + '</p>';
                    }

                    text += '</a>';
                });

                $searchResult.html(text);
                
                $(elementSelector).after($searchResult);

                $searchResult.children('a').click(function () {
                    callbackMethod($(this).attr('data-id'), $(this).attr('data-name'));
                    $searchResult.remove();
                    $(elementSelector).unbind();
                });

                searching = false;
            }
        });
    });
}

/*************************************************************************************************************/

function makeAjaxCall(url, method, successCallback, failureCallback, postParam, notExpectingAnyDataBack) {

    window.DisplayProgress();

    if (notExpectingAnyDataBack === null || notExpectingAnyDataBack === '') {
        notExpectingAnyDataBack = false;
    }

    $.ajax({
        url: url,
        type: method,
        data: postParam,
        success: function (data) {
            window.HideProgress();

            if (notExpectingAnyDataBack && (data == null || data.Description) ) {
                window.DisplayModal('Error', "Unknown error has occurred. Please try again later.");
                return;
            }

            successCallback(data);
        },
        fail: function (data) {
            window.HideProgress();

            if (data.Description) {
                window.DisplayModal('Error', data.Description);
                return;
            }

            failureCallback(data);
        }
    });
}

/*************************************************************************************************************/

function showDialog(modelObj) {

    var modalButtons = '';
    
    $('#bodyModalTitle').html(modelObj.title);
    $('#bodyModalBody').html(modelObj.body);

    modalButtons += '<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>';

    $.each(modelObj.buttons, function (index, item) {
        console.log('TYPE: ' + item.btntype);
        var btn = '<button class="btn ' + item.css + '" id="' + item.id + '" type="' + item.btntype + '">' + item.name + '</button>';
        modalButtons += btn;
    });

    $('#bodyModalFooter').html(modalButtons);
    $('#bodyModalContainer').modal('show');

    $.each(modelObj.buttons, function (index, item) {
        $('#' + item.id).off().click(function() {
            item.fireOnClick();
            $('#bodyModalContainer').modal('hide');
        });
    });
}


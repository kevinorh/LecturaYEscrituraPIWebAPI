$(document).ready( function (){
    //COMP VIEW MODE
    if($('link[href="/css/gridview-style.css"]').length === 1) {
        $('#grid-view').addClass('active');
    }
    else if ($('link[href="/css/listview-style.css"]').length === 1){
        $('#list-view').addClass('active');
    }
    //END COMP VIEW MODE

    $('input[type="date"]').change( function () {
        if ($(this).val() !== '') {
            $(this).css('color', '#000000');
        }
    });

    $('input[type="time"]').change( function () {
        if ($(this).val() !== '') {
            $(this).css('color', '#000000');
        }
    });
});

//DROPDOWN MENU
$('.tag-item-button-dropdown').click( function () {
    if(!$(this).hasClass('collapsed')){
        $(this).children().css('transform', 'rotate(180deg)');
    }
    else if($(this).hasClass('collapsed')){
        $(this).children().css('transform', 'rotate(360deg)');
    }
});
//END DROPDOWN MENU

//CHANGE TAG ITEM STATUS
$('.tag-item').click( function (e) {
    let div_title = $(this).children('.tag-disposition').children('.tag-item-header').children('.tag-item-title')[0];
    let text_title = $(this).children('.tag-disposition').children('.tag-item-header').children('.tag-item-title').children('span')[0];
    if(e.target === div_title || e.target === text_title) {
        if($(this).hasClass('active')){
            $(this).removeClass('active');
        }
        else if(!$(this).hasClass('active')){
            $(this).addClass('active');
        }
    }
});
//END CHANGE TAG ITEM STATUS

//CHANGE VIEW MODE
$('#list-view').click(function (){
    $('link[href="/css/gridview-style.css"]').attr('href','/css/listview-style.css');
    if(!$(this).hasClass('active')){
        $(this).addClass('active');
        $('#grid-view').removeClass('active');
    }
});
$('#grid-view').click(function (){
    $('link[href="/css/listview-style.css"]').attr('href','/css/gridview-style.css');
    if(!$(this).hasClass('active')){
        $(this).addClass('active');
        $('#list-view').removeClass('active');
    }
});
//END CHANGE VIEW MODE
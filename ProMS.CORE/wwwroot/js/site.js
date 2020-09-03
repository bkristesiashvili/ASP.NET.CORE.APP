// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
// apply dynamic padding at the top of the body according to the fixed navbar height
$(document).ready(function () {
    function onResize() {
        $("body").css("padding-top", $("#nav-bar").height() + 20);
    }

    // attach the function to the window resize event
    $(window).resize(onResize);

    // call it also when the page is ready after load or reload
    $(function () {
        onResize();
    });

    $(window).scroll(function () {
        if ($(this).scrollTop() > 50) {
            $('#back-to-top').fadeIn();
        } else {
            $('#back-to-top').fadeOut();
        }
    });
    // scroll body to 0px on click
    $('#back-to-top').click(function () {
        $('#back-to-top').tooltip('hide');
        $('body,html').animate({
            scrollTop: 0
        }, 800);
        return false;
    });

    $('#img').on('click', function () {
        $('#ProjectImage').trigger('click').on('change', function (e) {
            var readURL = function (input) {

                if (input.files && input.files[0]) {
                    var reader = new FileReader();

                    reader.onload = function (e) {
                        $('#img').attr('src', e.target.result);
                    }
                    reader.readAsDataURL(input.files[0]);
                }
            }
            readURL(this);
        });
    });

    $('.avatar').on('click', function () {
        $('#userImage').trigger('click').on('change', function () {
            var readURL = function (input) {

                if (input.files && input.files[0]) {
                    var reader = new FileReader();

                    reader.onload = function (e) {
                        $('.avatar').attr('src', e.target.result);
                    }
                    reader.readAsDataURL(input.files[0]);
                }
            }
            readURL(this);
        });
    });

    $('#chooseFile').on('click', function () {
        $('#projectFile').trigger('click').on('change', function () {
            var readURL = function (input) {

                if (input.files && input.files[0]) {
                    var reader = new FileReader();

                    reader.onload = function (e) {
                        $('#projectFile').attr('value', e.target.result);
                    }
                    reader.readAsDataURL(input.files[0]);
                }
            }
            readURL(this);
        });
    });

    $(document).on("click", "[type='checkbox']", function (e) {
        if (this.checked) {
            $(this).attr("value", "true");
        } else {
            $(this).attr("value", "false");
        }
    });
});

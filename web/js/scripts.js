(function ($) {
  jQuery(document).ready(function ($) {
    scroll();
    hamburger();
    navAlt();
    navHide();
    contactForm();
    $(window).scroll(function() {
      navAlt();
      navHide();
    });
  });
})(jQuery);

var scroll = function() {
  $(".scroll").click(function (event) { // When a link with the .scroll class is clicked
    event.preventDefault(); // Prevent the default action from occurring
    $('html,body').animate({
      scrollTop: $(this.hash).offset().top
    }, 500); // Animate the scroll to this link's href value
  });
}

var hamburger = function() {
  $('.hamburger-menu').on('click', function() {
    $('.bar').toggleClass('animate');
    $('nav ul.navbar').slideToggle('slow');
  });
}

var navAlt = function() {
  var x = $(window).scrollTop();
  var y = $(window).height();
  if ((x > y - 150 && x < y * 2 - 150) || (x > y * 3 - 150 && x < y * 4 - 150)) {
    $('nav').addClass('alt');
  } else {
    $('nav').removeClass('alt');
  }
}

var navHide = function() {
  var x = $(window).scrollTop();
  var y = $(window).height();
  if ((x>y*0.10 && !(x>y-125)) || (x>y*1.10 && !(x>y*2-125)) || (x>y*2.10 && !(x>y*3-125)) || (x>y*3.10 && !(x>y*4-125))) {
    $('nav').addClass('hide');
  } else if (x > y * 4.10) {
    $('nav').addClass('hide');
  } else {
    $('nav').removeClass('hide');
  }
}

var contactForm = function () {
  $("#contact-submit").on('click', function () {
    $contact_form = $('#contact-form');
    var fields = $contact_form.serialize();
    $.ajax({
      type: "POST",
      url: "js/contact.php",
      data: fields,
      dataType: 'json',
      success: function (response) {
        if (response.status) {
          $('#contact-form input').val('');
          $('#contact-form textarea').val('');
        }
        $('#response').empty().html(response.html);
      }
    });
    return false;
  });
}

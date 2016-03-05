(function ($) {
  jQuery(document).ready(function ($) {
    scroll();
    hamburger();
    navAlt();
    navHide();
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
  var fromTop = $(window).scrollTop();
  var windowHeight = $(window).height();
  if (fromTop > windowHeight - 150) {
    $('nav').addClass('alt');
  } else {
    $('nav').removeClass('alt');
  }
}

var navHide = function() {
  var fromTop = $(window).scrollTop();
  var windowHeight = $(window).height();
  if (fromTop > windowHeight / 10 && !(fromTop > windowHeight - 50) || fromTop > windowHeight * 1.10) {
    $('nav').addClass('hide');
  } else {
    $('nav').removeClass('hide');
  }
}

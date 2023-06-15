//Card Slider
$(document).ready(function () {
    var sliderWrapper = $('.slider-wrapper');
    var sliderItems = $('.slider-item');
    var totalItems = sliderItems.length;
    var currentIndex = 0;
    var slideInterval = setInterval(nextSlide, 3000);

    $('.next-btn').click(function () {
      nextSlide();
    });

    $('.prev-btn').click(function () {
      prevSlide();
    });

    function nextSlide() {
      currentIndex = (currentIndex + 1) % totalItems;
      updateSlider();
    }

    function prevSlide() {
      currentIndex = (currentIndex - 1 + totalItems) % totalItems;
      updateSlider();
    }

    function updateSlider() {
      var marginLeft = -currentIndex * 320;
      sliderWrapper.css('transform', 'translateX(' + marginLeft + 'px)');
    }

    function autoSlide() {
      nextSlide();
    }

    function startAutoSlide() {
      slideInterval = setInterval(autoSlide, 3000);
    }

    function stopAutoSlide() {
      clearInterval(slideInterval);
    }

    sliderWrapper.hover(function () {
      stopAutoSlide();
    }, function () {
      startAutoSlide();
    });

    startAutoSlide();
  });
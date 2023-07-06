////$(document).ready(function () {
////    var sliderWrapper = $('.slider-wrapper');
////    var sliderItems = $('.slider-item');
////    var slideWidth = sliderItems.first().outerWidth();
////    var currentIndex = 0;

////    function cloneCards() {
////        var clonedItems = sliderItems.clone();
////        sliderWrapper.append(clonedItems);
////    }

////    function slideToCurrent() {
////        var translateX = -currentIndex * slideWidth;
////        sliderWrapper.css('transition', 'transform 0.6s ease');
////        sliderWrapper.css('transform', 'translateX(' + translateX + 'px)');
////    }

////    function nextSlide() {
////        currentIndex++;
////        slideToCurrent();
////    }

////    function prevSlide() {
////        currentIndex--;
////        slideToCurrent();
////    }

////    function startAutoSlide() {
////        setInterval(function () {
////            cloneCards();
////            nextSlide();
////        }, 3000);
////    }

////    $('.slider-next-btn').click(function () {
////        cloneCards();
////        nextSlide();
////    });

////    $('.slider-prev-btn').click(function () {
////        cloneCards();
////        prevSlide();
////    });

////    startAutoSlide();
////});

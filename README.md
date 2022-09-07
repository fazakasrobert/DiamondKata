# DiamondKata - Robert Fazakas

## Notes
I have thought of few different ways to implement the problem, but eventually I have chosen the approach I thought would be the fastest but still readable. I have avoided too many string concatenations and the use of unnecessary iterations. As a result, the indexing of the array may not be the easiest to read, but it feels like a decent compromise. 

The unit tests may not run successfully on a linux machine due to different line breaks, but I didn't want to spend too much time on breaking out the constants into separate test methods. 

I couldn't think of a way to test the whole alphabet without typing them all out or building another diamond builder to then test the diamond builder, so I've only implemented test cases from A to E. This should prove that the code works as it will test each line of code. On top of the unit testing I've tested most of the letters manually via the console app as well.
# RandomCharacterGenerator

Prompt: Build a clone of $ cat /dev/random in the language of your choice, generating your own entropy.

## Execution:
            Usage: ./rndChrs.exe [OUTPUTLOC] [NUMCHARS] [--PRETTY]
            Prints out a string of random characters to a file or console.
              OUTPUTLOC is the optional filelocation to print to.
              NUMCHARS is the optional number of characters, if not specified, it will print infinitely.
              --PRETTY is the optional filter to exclude unprintable characters
            Examples:
              ./rndChrs.exe --HELP
                 Prints out this help text
              ./rndChrs.exe ./outputfolder/junk.txt 10000
                 Will write 10,000 characters to junk.txt
              ./rndChrs.exe 50 --pretty
                 Will output 50 printable characters to console

## Rational:
  "cat /dev/random" prints out characters from the pseudorandom number generator /dev/random. My implementation of this allows the user to do that, but also to specify the amount of characters, to print to a location, and to only print normal ascii characters. 

  I had originally used Math.Random(), which is a pseudorandom number generator. That random number generator is based on the Donald E. Knuth’s subtractive random number generator algorithm [1]. Other built in possibilities were the RNGCryptoServiceProvider class that provides a cryptographically safe random number, which is much better (but slower to generate). 

  In order to create my own pseudorandom number generator, I read up on the various types and tradeoffs between them. Since we are dealing with a situation where pseduo-randomness is okay and that the cryptographically strength of the generated results is not extremely important, it is okay to have a solution that prioritizes speed. The version I used, commonly called XorShift64[4] has a period of 2^64-1. This is by far not the most advanced or best tested method available, but it is extremely fast, very simple, and for this specific purpose, fine to use.

  If I were to take more time on this assignment, I would spend it on two things:
    1.) Determine a way to add more "noise" to the seed generation (rather than just using the computer clock), through various sources (probably mouse movements, current computer state information, and other variables that I find on Google to add). 
    2.) Look at better pseudorandom number generators and dig into the runtime vs statistically analysis of each one. 

## Resources Used:
```
[1] https://docs.microsoft.com/en-us/dotnet/api/system.random?view=netframework-4.8
[2] https://en.wikipedia.org/wiki/Random_number_generation
[3] https://en.wikipedia.org/wiki/Pseudorandom_number_generator
[4] https://en.wikipedia.org/wiki/Xorshift#xorshift*
```

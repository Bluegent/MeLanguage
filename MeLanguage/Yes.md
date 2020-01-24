# Weekly Workshops

Technology is always on the move, so as developers it is important that we, too, move along with it. In order to keep up with new ideas, reflect on what we already know, share knowledge and find valuable concepts that can be used in our product development, we have decided to regularly meet on Fridays and hold a 4 hour workshop where we explore different areas of the software development domain. 

#### Why:
Some of the reasons why a need for such a workshop rose:
1. Getting different technical perspectives that can add value to the product we are developing 
2. Increase as well as distribute our knowledge base
3. Learn from and adapt to industry paradigms and standards
4. Break the routine of daily work

#### How: 
This is how a typical session of the workshop goes:
1. Meet up every Friday from 10:00 AM to 2:00 PM
2. Try new technologies, methodologies, explore new paradigms, understand existing concepts
3. Order food and discuss our findings over lunch
4. Extract some conclusions, write them down if possible
5. If the result of the session is some code, we check it in to the [workshop repository](https://gitext.elektrobitautomotive.com/adne261703/development_workshop) 
6. Vote on topics for future workshops



#### What: 
Until now we've had 8 (2 FSeam +3 threading +1 arch +1 sock +1 functional programming) workshops over which we have approached the following topics:
1. FSeam mocking framework
2. Multi-threading in C++ 14/17 
3. Architecture role
4. Functional Programming
5. Sockets in C++

## FSeam

**Motivation:** Legacy code can be difficult to test with the unit testing approach of the Google Test framework without major changes and refactoring, so we looked for a way to ease this process and what we found was "FSeam: A Mocking Framework That Requires No Change In Code." How FSeam achieves this is by intervening during the linking process and substituting its mock implementation for the tested classes/methods etc.

**Advantages of FSeam:**
* Mocking without impacting production code
* Mocking default behavior (no need to access a particular instance of the mocked object to manipulate its behavior)
* Mocking of static / free functions as easily as any classes
* Header only library to include in test file

On our first session, we checked out FSeam on windows and attempted to build its example project, encountering many issue with its build setup and dependencies. We then tried to build it on Linux and managed to compile and run the example project, however we found it quite difficult to integrate simple external code into it.

**Result:**  We found this particular library troublesome to work with so we searched for alternatives to it within the same paradigm. It seems that the concept is in an incipient stage and may be applied sometime in the future when it gains more traction and its frameworks become more accessible.

|  FSeam | Evaluation   |
|---|---|
| Usefulness in product development  | ★★★★★  |
| Ease of implementation     | ★☆☆☆☆ |
| Ease of use			     | ★★★☆☆  |
| Usable |✓ |


## Multi-threading 
**Motivation:** We wanted to stay up to date with the growing C++ standard, understand synchronization mechanisms and see what concepts could enrich the parallel processing capabilities of GTF.

We started by exploring the concepts offered by the C++ 14/17 threading library such as `future`, `promise`, `conditional variable`, `atomic variable`, `thread`, etc. Over three sessions we have used these in the implementation of a library whose main purpose is offering an easy to use Thread Pool mechanism for executing tasks asynchronously.

**Result:** We acquired a better understanding of threading and some ideas as to how to improve/optimize GTF's multi-threading capabilities. The threading library we wrote can and most likely will be developed with additional functionality in future workshops.

|  C++ 14/17 Threading library | Evaluation   |
|---|---|
| Usefulness in product development  | ★★★★★  |
| Ease of implementation     | ★☆☆☆☆   |
| Ease of use			     | ★★★☆☆  |
| Usable |<sub> Currently we can only use some C++11 features</sub>| 

## Architecture role

**Motivation:**In order to have a better overview of the Software Architect role as well as a better understanding of what Software Architecture consists in and where it is applicable we had discussion on the key points provided by >>Book<<

For this session we extracted several ideas from the >>Book<< and debated them.

**Result:** We have gained more insight of this topic, clarified certain concepts and contoured the boundaries of the role.

## Functional Programming

**Motivation:** Explore programming paradigm different to Imperative Programming, see how it can be useful to us and find new problem solving approaches.

We studied Functional Programming concepts and then converted a simple imperative program to an Functional Programming program. As an added benefit, we also practiced using lambda expressions.

**Result:** As a positive result, the code is easier to read and is more transparent due to the lack of state changes, the purpose of every function is clear and has no side-effects. The focus is more on actions rather than objects. As a downside, the performance of your code is reduced. Due to the paradigm restrictions it is difficult to implement a purely functional program.

|  Functional Programming | Evaluation   |
|---|---|
| Usefulness in product development  | ★★★☆☆  |
| Ease of implementation     | ★★★☆☆  |
| Ease of use			     | ★☆☆☆☆  |
| Usable |<sub>Can be used sparingly</sub>| 

## Sockets in C++

**Motivation:** Sockets are a widely used method for inter process communication so the goal was to get an understanding of the mechanism.
Unfortunately the current available C++ standard libraries do not provide a platform agnostic library for working with sockets, so we made the decision that we will explore it on Windows.

We started with Microsoft's basic WinSock example, studied it until we understood the big picture, then started implementing a simple platform-dependent wrapper with the goal of eventually separating an interface out of it. We can then use that interface to create an operating system abstraction layer and then write code for Linux, Android, etc. 

**Results:** The topic is currently ongoing, the wrapper is in the development state.

|  Windows C++ Sockets | Evaluation   |
|---|---|
| Usefulness in product development  | ★★★★★  |
| Ease of implementation     | ★★☆☆☆  |
| Ease of use			     | ★★★☆☆  |
| Usable |✓| 


___
<sub>Table row explanation:</sub>

* <sub> **Usefulness in product development** - how useful it would be in the day-to-day development of our product </sub>
* <sub>  **Ease of implementation** - how easy it would be to write the code and integrate it into GTF</sub>
* <sub> **Ease of use** = how easy it would be to use it further (eg. write unit tests with a testing framework)</sub>
* <sub> **Usable** - whether the topic conforms to current product development restriction (eg. does it depend on a C++ feature we cannot use like exceptions)</sub>

# Basic Documentation
Satisfying the "Basic documentation" requirement, together with some code comments, I would like to throw some random notes explaining my decisions during development:
I had a lot of fun implementing the requirements, though my implementation is no brain surgery.
I did some kind of Repository (a bit of onion + mvvm) architecture, though from the perspective of the hours spent it made no sense.
I've added unit tests for the basic domain logic (conversion from byte to actual object data), but did not decide to implement full code coverage, since I do not think this is the true purpose of the task. [;
Also since there was no explicit architecture decision I've decided that parsing the actual domain objects from their byte representation is a matter the domain objects should handle themselves. 

The solution is developed under Visual Studio 2013 and tested with Nokia Lumia 920 (WP 8.1)

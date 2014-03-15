Listy-in-memory
===============

Yay checklist. In-memory reference implementation using ASP.NET. Note that this implementation is actually forked from the [Listy-aspnet-nhibernate](https://github.com/bendetat/Listy-aspnet-nhibernate) implementation.


## Things of note
It is very basic but there are some interesting things to be found:

- ASP.NET MVC (not much, it's a single page application)
- ASP.NET Web API
- Autofac
- System.Web.Optimization
	- i.e. bundled JS and CSS
	- This lets me break my JS down into lots of files that are combined in production, without having to write lots of `<script>` imports
- Twitter Bootstrap
- Knockout
- knockout-sortable


## Implementations

This list may not be up to date:

- [Listy-aspnet-nhibernate](https://github.com/bendetat/Listy-aspnet-nhibernate), uses NHibernate as the ORM
- [Listy-NServiceBus](https://github.com/bendetat/Listy-NServiceBus), adds an extremely basic NServiceBus backend for over-engineered fun times
- [Listy-Azure](https://github.com/bendetat/Listy-Azure), just getting the reference implementation running on Azure

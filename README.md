Listy-aspnet-nhibernate
=======================

Yay checklist. ASP.NET MVC and NHibernate

This is just a simple learning excercise mainly around hello worlding nhibernate. That's right I just verbed hello world.

You need a SQL Server localdb named `Tasky`. Running `ResetTheWorld.bat` will bootstrap the database. Everything else Should Just Work (tm).


## Things of note
It is very basic but there are some interesting things to be found:

- ASP.NET MVC (not much, it's a single page application)
- ASP.NET Web API
- Autofac
- DbUp
	- plus a nice little `ResetTheWorld`/`UpdateTheWorld` script
- NHibernate
	- Fluent Automapping
	- A custom foreign key convention (`[Bar].[FooId]` vs the default `[Bar].[Foo_Id]`)
- System.Web.Optimization
	- i.e. bundled JS and CSS
	- This lets me break my JS down into lots of files that are combined in production, without having to write lots of `<script>` imports
- Twitter Bootstrap
- Knockout
- knockout-sortable

## Future ideas
I might fork this to experiment with different implementations, such as:

- Coffeescript instead of Javascript
- Entity Framework instead of NHibernate
- Backbone mebbe


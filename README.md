# FINT.Model.Resource

FINT Resource Model contains the core classes for FINT data models containing HATEOAS relations.

## Usage

To add links to other resources, FINT resource classes contain `addXXX(Link)` methods for producing
specific links.

Links are URIs, typically https URIs.  The `Link` class has a static `Link.with(String)` that can be
used if the full URI to the target is known.

## Robust links

Full https URIs are sensitive to changes in the FINT API deployment configuration.  To ensure that
links are robust, the FINT APIs also support convenience methods that enables implementors to
generate links when the target Java class is known.  In these cases the methods
`Link.with(Link, String...)` or `Link.with(Type, String)` come in handy.  The first argument is the
Java class of the target resource, so to link to a `Person` you use
`Link.with(typeof(Person), ...)`.

The second parameter(s) are the path element that specify the identifier for the target.  They are
typically built using two fields, the name of the identifier field, and the identifier value.  To
produce a link to a `Person` with a `fodselsnummer` of `12345678901`, this becomes:

```csharp
Link linktoPerson = Link.with(typeof(Person), "fodselsnummer", "12345678901");
```

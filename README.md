# IdSetter
Efficient way of setting an object's "Id" field when this field can vary, and is set via an annotation

Finding a property of an object which has a specific annotation can be expensive when using reflection, particularly when setting many instances of an object, such as working with collections.

This code tries to find the most optimal way by creating a configuration / setter object for each new Type found. This object will at one time only, perform the necessary reflection steps to locate the property, and create a setter so that it can be invoked easily.

When working on future objects of the same type, the setter will be immediately available for invocation without repeating the same reflection steps.

The configuration / setter object will be implemented as a static Dictionary<Type, object>.

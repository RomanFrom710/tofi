Intro
===

Lets don't be animals and follow common code style.

## Remarks

 - No tabs, only spaces.
 - Use CamelCase for naming. By default ReSharper will tell you when your name is bad. 
 - Press Ctrl+R, Ctrl+W to view white space in Visual Studio. After you done editing document press Ctrl+K, Ctrl+D to format document. This will remove white space and do a bit more :)
 - Don't leave empty line at the end of file.
 - Always put access level explicitly.
 - The order of elements is defined by their access level: public, internal, protected, private. Also static goes first. And it would be nice not to mix virtual(overridden) elements with normal.
 - All structure elements are separated by 2 empty lines
 - Classes, properties, methods, constructors are separated by 1 empty line each.
 - Regions can be used to separate elements from previous point to underline logical groups. #region and #endregion elements should have 1 empty line below and above. 
 - Const, static, normal fields; events are not separated by empty line.
 - An empty line can be used to separate elements from previous point to underline logical groups.  

## Structure

 - Const fields
 - Static fields
 - Fields
 - Events
 - Properties
 - Constructors
 - Abstract methods
 - Methods
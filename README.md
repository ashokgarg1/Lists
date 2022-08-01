# Lists

See Program.cs for a demo of the working code

ListQueue is a custom implementation of a List<T> to mimmick a Queue<T> where T is  IQueueable.
It has the following custom features:

Unique - all items must have unique key,m otherwise they will be ignored and not queued
PushToTop: push the item to top to priortize it.

UpdateValue: update the item in queue

GetKeysAsString: user can get back a delimited string with keys for all items in the queue


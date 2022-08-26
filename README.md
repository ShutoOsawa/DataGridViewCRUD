# DataGridViewCRUD
DataGridView and CRUD with Winforms

Implemented in .NET Framework 4.8

This application can manage a list data in data grid view provided by windows forms.

#Usage
The user can modify the "ItemInfo" class. The current version has "Location", "Name", and "IPAddress" as column header.

#CRUD
Create: after filling all the text boxes out, the ItemInfo object is generated based on the implemented property. The object is loaded into the data grid view.
ItemInfo has properties and their name need to be identical to the textbox component name. The number of columns can be modified as long as this rule is satisfied.

Read: when a cell is clicked in the data grid view, the corresponding data will appear in the textboxes.

Update: after reading the data, the data can be updated by clicking Update button.

Delete: any rows can be deleted.

#XML save and load
There are Save and Load buttons on the form, and they can be used for saving the currently displayed list to a xml file. The saved xml file can be loaded by pressing the load button.

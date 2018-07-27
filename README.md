# Dev Portfolio Site C#/.NET

### Instructions
1. Clone the repo
2. Open/Load ./Cahnite.sln
3. run Update-Database in the package manager console
4. Build the project and, if there aren't any errors
5. Run the project (F5)

You'll find yourself looking at a list of projects, under a header. 

Each project can be clicked to view details.
Detail view contains the Edit link.
Inside the edit view you can edit, delete or cancel.

There are 2 checkboxes in the edit view with extra functionality. 

1. Republish to front of list will update that projects "created on" value so that it jumps back up to the front of the list view.
2. The Publish checkbox displays the project on the index page if checked, and if unchecked it will be moved to the unpublished projects list with
the idea being that you can pre-build projects and publish them later, or un-publish while making edits. 
You'll see an alert if you're editing a currently unpublished project.

### TODO:

1. There's no confirmation for the delete button, you click it and it's gone, that should be fixed.
2. Add user authentication so it can be published live.

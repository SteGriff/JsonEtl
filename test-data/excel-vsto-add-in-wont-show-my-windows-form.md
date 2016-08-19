# Excel VSTO add-in won't show my Windows Form

You put the Windows Form in a separate project because you were trying to be a good engineer, didn't you?

Excel can't load the dependency DLL so it can't/won't display your form. Move your form into the same project as the add-in (You could create a `GUI` or `Forms` folder with its own namespace)

## Example

These are example event handlers on Ribbon buttons.

### Simple MessageBox - works fine

	private void goButton_Click(object sender, RibbonControlEventArgs e)
	{
		MessageBox.Show("Hello world");
	}

### Create an anonymous form and display it - works fine
	
	private void goButton_Click(object sender, RibbonControlEventArgs e)
	{
		var win = new Form();
		win.Text = "New Form";
		win.Size = new Size(600, 400);
		win.Location = new System.Drawing.Point(100,100);
		win.Show();
	}
	
### Display a form from another project - won't even hit breakpoint on first line

	private void goButton_Click(object sender, RibbonControlEventArgs e)
	{
		string junk = "Excel will not execute any part of this method. Not even this line.";
		
		//Namespace used to illustrate that it's in a different project
		var setupForm = new GuiProject.SetupForm();
        setupForm.Show();
	}
	
### Display a form from same project - should work

	private void goButton_Click(object sender, RibbonControlEventArgs e)
	{
		//SetupForm can be in its own namespace as long as it's in this project! :)
		var setupForm = new GUI.SetupForm();
        setupForm.Show();
	}
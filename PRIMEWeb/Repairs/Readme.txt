 
// Add these to the top of every page load of rest of the main options to clear the criteria that the service and repair was filtered on
Session["ServiceCriteria"] = null
Session["RepairCriteria"] = null;


// Add these to the top of every page load of rest of the main options so that the details view know not to show create or edit success msg 
Session["editRedirect"] = null;
Session["createRedirect"] = null;

&#10004; - tick
&#x274C; - x
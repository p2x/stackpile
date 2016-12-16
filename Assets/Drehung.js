#pragma strict
    var targetAngle = 0;
    var degreesPerClick = 0;
    var secsPerClick = 0.3;
   
    private var curAngle = 0f;
    private var startAngle=0f;
    private var startTime=0f;
     
    function Update () {
        var clicks = Mathf.Round(Input.GetAxis("Mouse ScrollWheel") * 20);
        if (clicks != 0) {
            targetAngle += clicks * degreesPerClick;
            startAngle = curAngle;
            startTime = Time.time;
        }
       
        var t = (Time.time - startTime) / secsPerClick;
        if (t <= 1) {
            curAngle = Mathf.Lerp(startAngle, targetAngle, t);
            // finally, do the actual rotation
            transform.eulerAngles.y = curAngle;
            transform.eulerAngles.x= curAngle;
            transform.eulerAngles.z=curAngle;
        }
           
 
    }
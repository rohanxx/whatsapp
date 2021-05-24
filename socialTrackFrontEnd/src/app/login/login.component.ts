import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AppService } from '../app.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  LogInForm: FormGroup;
  submitted = false;
  

  constructor(private fb: FormBuilder, private appService: AppService, private route: Router) { 
    window.location.hash="no-back-button";
window.location.hash="Again-No-back-button";//again because google chrome don't insert first hash into history
window.onhashchange=function(){window.location.hash="no-back-button";}

  }

  ngOnInit() {
    this.LogInForm = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }
  

  get formControls() { return this.LogInForm.controls; }

  login() {
    this.submitted = true;
    if(this.LogInForm.valid){
      let data = {
        Email: this.LogInForm.value.email,
        Password: this.LogInForm.value.password
      }
      this.appService.signin(data).subscribe((x:any)=>{
        if(x.statusCode==200){
          localStorage.setItem('ID', x.responseData.id);
          localStorage.setItem('firstName', x.responseData.first_Name);
        this.route.navigate(["dashbord"]);
     
        }else{
          window.alert(x.message);
          console.error("user not found");
        }
      })
    } 
  };
  
  get LogInFormControls() {
    return this.LogInForm.controls;
  }
}

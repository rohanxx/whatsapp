import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AppService } from '../app.service';
import { MustMatch } from '../Shared/_directive/must-match.validator.module';

@Component({
  selector: 'app-addnew-users',
  templateUrl: './addnew-users.component.html',
  styleUrls: ['./addnew-users.component.css']
})
export class AddnewUsersComponent implements OnInit {

  RegisterForm: FormGroup;
  constructor(private fb: FormBuilder, private appService: AppService, private route: Router) { }

  ngOnInit() {
    this.createForm();
  }
  MustMatch(control: AbstractControl): ValidationErrors | null {
 
    const password = control.get("password").value;
    const confirm = control.get("confirm").value;
 
 
    if (password != confirm) { return { 'noMatch': true } }
 
    return null
 
  }
 
  
  createForm(){
    this.RegisterForm = this.fb.group({
      mobile_n: ['',[Validators.required, Validators.pattern('^[0-9]'),Validators.maxLength(10)]], 
      F_name: ['', [Validators.required,Validators.pattern(/^[A-Za-z]+$/),Validators.maxLength(25)]],
      L_name: ['', [Validators.required,Validators.pattern(/^[A-Za-z]+$/),Validators.maxLength(25)]],
      email: ['', [Validators.required, Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$')]], 
      password: ['', [Validators.required, Validators.pattern('(?=.*[A-Za-z])(?=.*[0-9])(?=.*[$@$!#^~%*?&,.<>"\'\\;:\{\\\}\\\[\\\]\\\|\\\+\\\-\\\=\\\_\\\)\\\(\\\)\\\`\\\/\\\\\\]])[A-Za-z0-9\d$@].{7,}')]],  
      confirmPassword: ['', Validators.required],
      
  }, {
      validator: MustMatch('password', 'confirmPassword')
  });
  };

  get formControls() { return this.RegisterForm.controls; }

  Register() {
    if(this.RegisterForm.valid){
      //  this.route.navigate(["/"]);
      

      //  NOTE: uncomment after connect with new api
      let data = {
        FirstName: this.RegisterForm.value.F_name,
        LastName: this.RegisterForm.value.L_name,
       
        password: this.RegisterForm.value.password,
        conformpassword: this.RegisterForm.value.confirmPassword,
        PhoneNumber: this.RegisterForm.value.mobile_n,
        
      }
      this.appService.signin(data).subscribe((x:any)=>{
        if(x.statusCode==200){
          window.alert(x.message);
        this.route.navigate(["/"]);
        console.info("user",this.RegisterForm);
        }else{
          window.alert(x.message);
          console.error("user not found");
        }
      })
    } 
  };
 
}

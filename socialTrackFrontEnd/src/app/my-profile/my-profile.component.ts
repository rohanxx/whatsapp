import { AppService } from './../app.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {

  profileForm: FormGroup;
  constructor(private appService:AppService) { }

  ngOnInit() {
    this.profileForm =  new FormGroup({
      firstname: new FormControl('', [Validators.required]),
      lastname: new FormControl(''),
      email: new FormControl({value: '', disabled: true}),
      contact: new FormControl(''),
      password: new FormControl('')
    });

    this.getProfileData();
  }

  onSubmit(){
    if (this.profileForm.invalid) {
      return;
    }

    this.profileForm.value.id = localStorage.getItem('ID');
   
    this.appService.editProfile(this.profileForm.value).subscribe((response: any) => {
      if(response.statusCode==200){
        alert(response.message);
        this.getProfileData();
      }
    })
  }

  getProfileData() {
    let id=localStorage.getItem('ID');
    this.appService.getProfileData(id).subscribe((response: any) =>{
      if(response.statusCode==200){
        const { first_Name,last_Name,email,contact, password} = response.responseData;
        this.profileForm.setValue({
          firstname: first_Name,
          lastname: last_Name,
          email:email,
          contact:contact,
          password:password
        });
      }
    });
  }
}

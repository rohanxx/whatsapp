import { FormControl, FormGroup } from '@angular/forms';
import { Component, OnInit, ViewChild, enableProdMode } from '@angular/core';
import { AdminService } from '../Admin_Service';
import { arrowLeftRight } from 'ngx-bootstrap-icons';

@Component({
  selector: 'app-admin-com',
  templateUrl: './admin-com.component.html',
  styleUrls: ['./admin-com.component.css']
})
export class AdminComComponent implements OnInit {

  constructor(private Adminservice: AdminService) { }
  Adminlist:any[];
  adminForm: FormGroup;
  currentRowId:any;

  @ViewChild('addAdmin', {  static: true  }) addModal;
  @ViewChild('updateAdmin', {  static: true  }) updateAdmin;

  ngOnInit() {
    this.adminForm = new FormGroup({
      firstname: new FormControl(),
      lastname: new FormControl(),
      email: new FormControl(),
      contact: new FormControl(),
      password: new FormControl()
    });

    this.getAllAdmins();
  }

  getAllAdmins(){
   this.Adminservice.GetAdmin().subscribe((data: any) => {
        if (data.statusCode == 200) {
          this.Adminlist = data.responseData;
        }
      });
  }

  DeleteAdmin(id) {
    this.Adminservice.DeleteAdmin(id).subscribe((data: any) => {
      if (data.statusCode == 200) {
        this.getAllAdmins();
      }
      else {
        alert("Error while deleting Admin");
      }
    })
  }


  updateAdminData(){
    if(!this.adminForm.valid) {
      return;
    }

    this.adminForm.value.adminId = this.currentRowId;

    this.Adminservice.updateAdmin(this.adminForm.value).subscribe((data:any)=>{
      if(data.statusCode == 200) {
        this.updateAdmin.close();
        this.getAllAdmins();
      }
      else{
        console.info("no data found")
      }
    })
  }

  addNewAdmin() {
      if(!this.adminForm.valid) {
        return;
      }

      this.Adminservice.NewAdmin(this.adminForm.value).subscribe((res:any) => {
        if(res.statusCode == 200) {
          this.addModal.close();
          this.getAllAdmins();
        }
        else {
          alert("Error while adding Admin");
        }
      });
  }

  openAdminPopup(adminData) {
    this.adminForm.setValue({
      firstname: adminData.firstName,
      lastname: adminData.lastName,
      email: adminData.email,
      contact: adminData.contact_No,
      password: null
    });

    this.currentRowId = adminData.id;

    this.updateAdmin.open();
  }
}


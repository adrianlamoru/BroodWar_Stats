import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup = this.fb.group({
    UserName: [, [Validators.required, Validators.minLength(3)]],
    Password: [, [Validators.required, Validators.minLength(3)]],
  });

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {}

  
}

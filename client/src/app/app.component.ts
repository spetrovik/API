import { HttpClient } from '@angular/common/http';
import { ValueConverter } from '@angular/compiler/src/render3/view/template';
import { Component, ElementRef, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UniquePipe } from './customPipe/uniquePipe';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  @ViewChild('f') coffeeMachine: NgForm;
  title = 'Coffee Vending Machine'
  coffees: any
  ingridients: any
  ingridientsCustom: any;
  ingridientName: string = "";
  ingridientQuantity: string = ''

  coffeeIngridients: any;

  coffeeType: string = "";

  uniqueIngridients: any
  quantity: any;
  isDisabled: boolean = false;
  submitted: boolean = false;
  changed: boolean = false;
  typeOfCoffee = {
    id: '',
    name: '',
    ingridient: '',
    quantity: ''
  }
  

  constructor(private http: HttpClient, public uniquePipe: UniquePipe) {
  }

  ngOnInit() {
    this.getCoffees();
    this.getIngridients();
  }
  getCoffees() {
    this.http.get('https://localhost:5001/api/coffee/GetCoffees')
      .subscribe(response => {
        this.coffees = response, error => {
          console.log(error);
        }
      }
      );
  }
  getIngridients() {
    this.http.get('https://localhost:5001/api/coffee/GetIngridients')
      .subscribe(response => {
        this.ingridients = response, this.uniqueIngridients = response, this.ingridientsCustom = response, error => {
          console.log(error);
        }
      }
      );
  }

  onSubmit(form: NgForm) {
    if(this.changed){

    for (var ingridientCustom of this.uniqueIngridients) {

      if (ingridientCustom.ingridientQuantity == "0") 
      {
        ingridientCustom.ingridientQuantity = "none";
      }
     if(Number.isInteger(ingridientCustom.ingridientQuantity))
      {
      this.typeOfCoffee.name = this.coffeeMachine.value.coffeeType;
      this.typeOfCoffee.ingridient += ingridientCustom.name + " - Quantity: " + ingridientCustom.ingridientQuantity + " ";
      }
    
    }
  }
  else{
    this.uniqueIngridients = this.uniquePipe.transform(this.uniqueIngridients);
    for (var ingridientCustom of this.ingridientsCustom) {

      if (ingridientCustom.ingridientQuantity == "0") 
      {
        ingridientCustom.ingridientQuantity = "none";
      }
      this.typeOfCoffee.name = this.coffeeMachine.value.coffeeType;
      this.typeOfCoffee.ingridient += ingridientCustom.name + "-" + ingridientCustom.ingridientQuantity + " ";
    }
  }
    this.isDisabled = true;
    this.submitted = true;
    this.coffeeMachine.reset();
  }
  onChange(checked, ingridient, form: NgForm) {
    this.changed = true;
    if (checked) {
      ingridient.ingridientQuantity = form.value.ingridientQuantity;
    }
  }
  changeCoffee(id: string) {

    this.ingridientsCustom = this.ingridients.filter((ingridient) => ingridient.coffeeId == id);
    this.typeOfCoffee.name = this.coffeeMachine.value.coffeeType.name;
    this.typeOfCoffee.ingridient = "";
    this.submitted = false;
    this.isDisabled = false;
  }
}
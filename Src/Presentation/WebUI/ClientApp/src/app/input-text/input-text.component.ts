import { Component, EventEmitter, Input, Optional, Output, Self } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
    selector: 'app-input-text',
    templateUrl: './input-text.component.html',
    styleUrls: ['./input-text.component.scss']
})
/** input-text component*/
export class InputTextComponent implements ControlValueAccessor {

  @Input()
  public caption: string;

  @Input()
  public placeholder: string;

  @Input()
  public required = false;

  @Input()
  public disabled = false;

  @Input()
  public data: string = null;

  @Input()
  public minlength = 0;


  protected _value: any;
  @Input('value')
  get value() {
    return this.data;
  }
  @Output() valueChange = new EventEmitter();
  set value(val) {
    this.data = val;
    //
    this.valueChange.emit(this._value);
  }



  @Input('isRequired')
  get isRequired() {
    return this.required;
  } set isRequired(val) {
    this.required = val;
  }

  get placeholderText() {

    if (this.placeholder) {
      return this.placeholder
    }
    else if (this.required) {
      return this.required ? 'Required' : '';
    }
    else {
      return '';
    }
  }




  private errorMessages = new Map<string, () => string>();

  public onChangeFn = (_: any) => {

  };

  public onTouchedFn = () => {

  };

  constructor(@Self() @Optional() public control: NgControl) {
    this.control && (this.control.valueAccessor = this);
    this.errorMessages.set('required', () => `${this.caption} is required.`);
    this.errorMessages.set('minlength', () => `The no. of characters should not be less than ${this.minlength}.`);
  }

  public get invalid(): boolean {
    return this.control ? this.control.invalid : false;
  }

  public get showError(): boolean {
    if (!this.control) {
      return false;
    }

    const { dirty, touched } = this.control;

    return this.invalid ? (dirty || touched) : false;
  }

  public get errors(): Array<string> {
    if (!this.control) {
      return [];
    }

    const { errors } = this.control;
    return Object.keys(errors).map(key => this.errorMessages.has(key) ? this.errorMessages.get(key)() : <string>errors[key] || key);
  }

  public registerOnChange(fn: any): void {
    this.onChangeFn = fn;
  }

  public registerOnTouched(fn: any): void {
    this.onTouchedFn = fn;
  }

  public setDisabledState(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }

  public writeValue(obj: any): void {
    this.data = obj;
    //console.log('writeValue', obj);
  }

  public onChange() {
    this.onChangeFn(this.data);
  }

}

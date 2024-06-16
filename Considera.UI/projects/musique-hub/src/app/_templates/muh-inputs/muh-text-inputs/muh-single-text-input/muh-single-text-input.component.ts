import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'muh-single-text-input',
  templateUrl: './muh-single-text-input.component.html',
  styleUrls: ['./muh-single-text-input.component.scss']
})
export class MuhSingleTextInputComponent {
  @Input() public label: string = '';
  @Input() public icon: string = '';
  @Input() public required: boolean = false;
  public input: string = '';
  @Output() public inputValue: EventEmitter<string> = new EventEmitter<string>();

  public onInputChange(): void {
    this.inputValue.emit(this.input);
  }

  public clear(): void {
    this.input = '';
  }
}

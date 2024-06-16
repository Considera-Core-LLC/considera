import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'muh-date-input',
  templateUrl: './muh-date-input.component.html',
  styleUrls: ['./muh-date-input.component.scss']
})
export class MuhDateInputComponent {
  @Input() public label: string = '';
  @Input() public icon: string = '';
  @Input() public required: boolean = false;
  public input: string = '';
  @Output() public inputValue: EventEmitter<string> = new EventEmitter<string>();

  public onInputChange(): void {
    this.inputValue.emit(this.input);
  }
}

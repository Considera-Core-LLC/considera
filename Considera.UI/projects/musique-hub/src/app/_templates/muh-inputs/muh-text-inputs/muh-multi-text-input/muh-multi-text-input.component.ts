import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'muh-multi-text-input',
  templateUrl: './muh-multi-text-input.component.html',
  styleUrls: ['./muh-multi-text-input.component.scss']
})
export class MuhMultiTextInputComponent {
  @Input() public label: string = '';
  @Input() public icon: string = '';
  @Input() public required: boolean = false;
  public input: string = '';
  @Output() public inputValue: EventEmitter<string> = new EventEmitter<string>();

  public onInputChange(): void {
    this.inputValue.emit(this.input);
  }
}

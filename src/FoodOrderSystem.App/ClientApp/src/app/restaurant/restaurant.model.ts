export class RestaurantModel {
  constructor() {
    this.address = new AddressModel();
    this.deliveryTimes = new Array<DeliveryTimeModel>();
  }

  public id: string;

  public image: string;

  public name: string;

  public address: AddressModel;

  public deliveryTimes: DeliveryTimeModel[];

  public nextDeliveryTime: string;

  public nextDeliveryTimeText: string;

  public minimumOrderValue: number;

  public minimumOrderValueText: string;

  public deliveryCosts: number;

  public deliveryCostsText: string;

  public phone: string;

  public webSite: string;

  public imprint: string;

  public orderEmailAddress: string;
}

export class AddressModel {
  constructor() { }

  public street: string;

  public zipCode: string;

  public city: string;
}

export class DeliveryTimeModel {
  constructor() { }

  public dayOfWeek: number;

  public start: number;

  public end: number;
}

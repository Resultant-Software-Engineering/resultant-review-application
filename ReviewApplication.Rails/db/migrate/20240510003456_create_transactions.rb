class CreateTransactions < ActiveRecord::Migration[7.1]
  def change
    create_table :transactions do |t|
      t.references :bank_account, null: false, foreign_key: true
      t.decimal :amount
      t.string :kind

      t.timestamps
    end
  end
end

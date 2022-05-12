<template>
  <v-dialog v-model="display" :width="dialogWidth">
    <template v-slot:activator="{ on }">
      <v-text-field
        v-bind="textFieldProps"
        :disabled="disabled"
        :loading="loading"
        :label="label"
        :value="formattedDateTime"
        v-on="on"
        prepend-icon="mdi-calendar-clock"
        readonly
      >
        <template v-slot:progress>
          <slot name="progress">
            <v-progress-linear
              color="primary"
              indeterminate
              absolute
              height="2"
            ></v-progress-linear>
          </slot>
        </template>
      </v-text-field>
    </template>

    <v-card>
      <v-card-text class="px-0 py-0">
        <v-tabs fixed-tabs v-model="activeTab">
          <v-tab key="calendar">
            <slot name="dateIcon">
              <v-icon>event</v-icon>
            </slot>
          </v-tab>
          <v-tab key="timer" :disabled="dateSelected">
            <slot name="timeIcon">
              <v-icon>access_time</v-icon>
            </slot>
          </v-tab>
          <v-tab-item key="calendar">
            <v-date-picker
              v-model="date"
              v-bind="datePickerProps"
              @input="showTimePicker"
              full-width
            ></v-date-picker>
          </v-tab-item>
          <v-tab-item key="timer">
            <v-time-picker
              ref="timer"
              class="v-time-picker-custom"
              v-model="time"
              v-bind="timePickerProps"
              full-width
            ></v-time-picker>
          </v-tab-item>
        </v-tabs>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <slot name="actions" :parent="this">
          <v-btn color="grey lighten-1" text @click.native="clearHandler">{{
            clearText
          }}</v-btn>
          <v-btn color="green darken-1" text @click="okHandler">{{
            okText
          }}</v-btn>
        </slot>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
// import { format, parse } from "date-fns";
import moment from "moment";
const DEFAULT_DATETIME_FORMAT = "YYYY-MM-DDTHH:mm:ss[Z]";
const DEFAULT_DATE_FORMAT = "YYYY-MM-DD";
const DEFAULT_TIME_FORMAT = "HH:mm:ss";
const DEFAULT_DATETIME = moment().format();
const DEFAULT_DATE = moment(DEFAULT_DATETIME).format(DEFAULT_DATE_FORMAT);
const DEFAULT_TIME = moment(DEFAULT_DATETIME).format(DEFAULT_TIME_FORMAT);
const DEFAULT_DIALOG_WIDTH = 340;
const DEFAULT_CLEAR_TEXT = "CLEAR";
const DEFAULT_OK_TEXT = "OK";
export default {
  name: "v-datetime-picker",
  model: {
    prop: "datetime",
    event: "input",
  },
  props: {
    datetime: {
      type: [Date, String],
      default: null,
    },
    disabled: {
      type: Boolean,
    },
    loading: {
      type: Boolean,
    },
    label: {
      type: String,
      default: "",
    },
    dialogWidth: {
      type: Number,
      default: DEFAULT_DIALOG_WIDTH,
    },
    dateFormat: {
      type: String,
      default: DEFAULT_DATE_FORMAT,
    },
    timeFormat: {
      type: String,
      default: DEFAULT_TIME_FORMAT,
    },
    clearText: {
      type: String,
      default: DEFAULT_CLEAR_TEXT,
    },
    okText: {
      type: String,
      default: DEFAULT_OK_TEXT,
    },
    textFieldProps: {
      type: Object,
    },
    datePickerProps: {
      type: Object,
    },
    timePickerProps: {
      type: Object,
    },
  },
  data() {
    return {
      display: false,
      activeTab: 0,
      date: DEFAULT_DATE,
      time: DEFAULT_TIME,
    };
  },
  mounted() {
    this.init();
  },
  computed: {
    dateTimeFormat() {
      return DEFAULT_DATETIME_FORMAT;
    },
    formattedDateTime() {
      return moment(this.selectedDatetime).format("YYYY-MM-DD HH:mm");
    },
    selectedDatetime() {
      if (this.date && this.time) {
        let datetimeString = this.date + "T" + this.time;
        if (this.time.length === 5) {
          datetimeString += ":00";
        }
        return moment(datetimeString).format();
      } else {
        return null;
      }
    },
    dateSelected() {
      return !this.date;
    },
  },
  methods: {
    init() {
      let initDateTime;
      if (!this.datetime || this.datetime == "") {
        initDateTime = moment().format();
      } else {
        initDateTime = moment(this.datetime).format();
      }

      this.date = moment(initDateTime).format(DEFAULT_DATE_FORMAT);
      this.time = moment(initDateTime).format(DEFAULT_TIME_FORMAT);
      this.$emit("input", this.selectedDatetime);
    },
    okHandler() {
      this.resetPicker();
      this.$emit("input", this.selectedDatetime);
    },
    clearHandler() {
      this.resetPicker();
      this.date = DEFAULT_DATE;
      this.time = DEFAULT_TIME;
      this.$emit("input", this.selectedDatetime);
    },
    resetPicker() {
      this.display = false;
      this.activeTab = 0;
      if (this.$refs.timer) {
        this.$refs.timer.selectingHour = true;
      }
    },
    showTimePicker() {
      this.activeTab = 1;
    },
  },
  watch: {
    datetime: function () {
      this.init();
    },
  },
};
</script>

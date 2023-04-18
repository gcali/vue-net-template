<template lang="pug">
.file-input
    input(
        type="file",
        ref="file-input",
        style="display: none",
        @change="loadFile"
    )
    button(@click="openFileInput") {{ label }}
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
    props: {
        label: String,
    },
    methods: {
        openFileInput() {
            const input = this.input;
            if (input) {
                input.click();
            }
        },
        async loadFile() {
            const files = this.input.files;
            if (files) {
                const file = files[0];
                console.log(file);
                if (file) {
                    this.input.value = "";
                    this.$emit("loaded", file);
                }
            }
        },
    },
    computed: {
        input() {
            const input = this.$refs["file-input"] as HTMLInputElement;
            return input;
        },
    },
});
</script>